package io.github.ksrgtech.dape.user.database

import cats.effect.kernel.Async
import cats.implicits.*
import neotypes.AsyncDriver
import neotypes.mappers.ResultMapper
import neotypes.syntax.all.*
import io.github.ksrgtech.dape.user.model.{LocalRegisteredUser, User, UserId}

trait UserRepository[F[_]] {
  def hasRootUser: F[Boolean]
  def findUserByPreferredHandle(preferredHandle: String): F[Boolean]
  def insertUser(user: LocalRegisteredUser): F[Unit]
  def createRootUser(user: LocalRegisteredUser): F[Unit]
}

final class UserRepositoryImpl[F[_]: Async](driver: AsyncDriver[F]) extends UserRepository[F] {

  override def hasRootUser: F[Boolean] = {
    val query = "MATCH (u:User { root: true }) RETURN u LIMIT 1"
    query.query(ResultMapper.option(using ResultMapper.ignore)).single(driver).map(_.isDefined)
  }

  override def findUserByPreferredHandle(preferredHandle: String): F[Boolean] =
    c"MATCH (n:Person { handle: $preferredHandle }) RETURN true AS exists LIMIT 1"
      .query(ResultMapper.option(using ResultMapper.boolean))
      .single(driver)
      .map(_.getOrElse(false))

  private def assertPreferredHandleUniqueness(user: User): F[Unit] =
    findUserByPreferredHandle(user.preferredHandle).flatMap { exists =>
      if exists then {
        Async[F].raiseError(
          new IllegalArgumentException(s"Already registered: ${user.preferredHandle}")
        )
      } else {
        Async[F].unit
      }
    }

  override def insertUser(user: LocalRegisteredUser): F[Unit] =
    for {
      _ <- assertPreferredHandleUniqueness(user)
      handle = user.preferredHandle
      id     = user.getIdentifier.raw.toString
      _ <- c"CREATE (n:Person { handle: $handle, id: $id })".execute.void(driver)
    } yield ()

  override def createRootUser(user: LocalRegisteredUser): F[Unit] =
    hasRootUser.flatMap { exists =>
      if exists then {
        Async[F].raiseError(
          new IllegalStateException("Root user already exists")
        )
      } else {
        insertUser(user)
      }
    }
}
