﻿using BLL.ViewModels;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface INewsService : IService<News, NewsViewModel>
    {
    }
}
