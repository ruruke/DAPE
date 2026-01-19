package io.github.ksrgtech.dape.user.service

import cats.effect.kernel.Sync

import java.security.SecureRandom

object PasswordGenerator {

  // Character set (excluding l, 1, O, 0 for readability)
  private val Alphabet: String =
    // Uppercase (excluding O)
    "ABCDEFGHJKLMNPQRSTUVWXYZ" +
      // Lowercase (excluding l)
      "abcdefghijkmnopqrstuvwxyz" +
      // Numbers (excluding 0 and 1)
      "23456789" +
      // Symbols (adjustable)
      "!@#$%^&*()-_=+[]{}|;:,.<>?"

  def generate[F[_]: Sync](length: Int = 20): F[String] =
    Sync[F].delay {
      require(length > 0, "length must be positive")
      val rng = new SecureRandom()
      val sb  = new StringBuilder(length)
      for _ <- 0 until length do {
        val index = rng.nextInt(Alphabet.length)
        sb.append(Alphabet.charAt(index))
      }
      sb.toString()
    }
}
