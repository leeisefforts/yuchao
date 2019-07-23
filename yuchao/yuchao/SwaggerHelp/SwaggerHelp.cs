﻿using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yuchao.SwaggerHelp
{
    public class SwaggerHelp
    {
        /// <summary>
        /// Swagger注释帮助类
        /// </summary>
        public class SwaggerDocTag : IDocumentFilter
        {
            /// <summary>
            /// 添加附加注释
            /// </summary>
            /// <param name="swaggerDoc"></param>
            /// <param name="context"></param>
            public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
            {
                swaggerDoc.Tags = new List<Tag>
            {
                //添加对应的控制器描述 
                new Tag { Name = "Values", Description = "测试模块" },
                new Tag { Name = "RefereeApply", Description = "裁判申请" },
            };
            }
        }
    }
}
