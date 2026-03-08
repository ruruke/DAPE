package io.github.ksrgtech.dape.base.cats

import cats.ApplicativeError

import scala.quoted.Expr

extension [F[_]](ae: ApplicativeError[F, Throwable]) {
  inline def assert(condition: Boolean, message: => String)/* (using CanThrow[IllegalArgumentException]) */: F[Unit] =
    if (condition) ae.unit
    else ae.raiseError(new IllegalArgumentException(message))
}
