package io.github.ksrgtech.dape.base.random

import cats.effect.kernel.Sync
import java.security.SecureRandom

object SecureRNG {

  def generateBytes[F[_]: Sync](length: Int): F[Array[Byte]] =
    Sync[F].delay {
      val rng = new SecureRandom()
      val ret = new Array[Byte](length)
      rng.nextBytes(ret)
      ret
    }

  def fillBytes[F[_]: Sync](destination: Array[Byte]): F[Unit] =
    Sync[F].delay {
      val rng = new SecureRandom()
      rng.nextBytes(destination)
    }
}
