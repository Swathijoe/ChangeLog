using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Core.Context
{
    public interface IContextGenerator
    {
        ChangeLogContext GenerateContext();
    }
}
