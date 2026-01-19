package io.github.ksrgtech.dape.user.service

import cats.effect.kernel.Sync
import cats.implicits.*
import com.password4j.Argon2Function
import io.github.ksrgtech.dape.base.random.SecureRNG
import io.github.ksrgtech.dape.user.model.HashedPassword

object PasswordHasher {
  private val SaltLength: Int  = 32
  private val HashLength: Int  = 128
  private val Iterations: Int  = 2
  private val MemorySize: Int  = 65536
  private val Parallelism: Int = 2

  def createHashedPassword[F[_]: Sync](input: String): F[HashedPassword] =
    for {
      salt <- SecureRNG.generateBytes[F](SaltLength)
      hash <- Sync[F].delay {
        val argon2 = Argon2Function.getInstance(
          MemorySize,
          Iterations,
          Parallelism,
          HashLength,
          com.password4j.types.Argon2.ID
        )
        argon2.hash(input.getBytes("UTF-8"), salt).getBytes
      }
    } yield HashedPassword(hash, salt, Iterations, MemorySize, Parallelism)
}
