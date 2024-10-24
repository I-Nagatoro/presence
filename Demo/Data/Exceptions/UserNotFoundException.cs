﻿using System;

namespace Demo.Data.Exceptions
{
    public class UserNotFoundException : RepositoryException
    {
        public UserNotFoundException(int userId)
            : base($"Пользователь с ID {userId} не найден.") { }
    }
}