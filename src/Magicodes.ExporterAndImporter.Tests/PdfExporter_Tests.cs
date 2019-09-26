﻿// ======================================================================
// 
//           Copyright (C) 2019-2030 湖南心莱信息科技有限公司
//           All rights reserved
// 
//           filename : PdfExporter_Tests.cs
//           description :
// 
//           created by 雪雁 at  2019-09-26 14:59
//           文档官网：https://docs.xin-lai.com
//           公众号教程：麦扣聊技术
//           QQ群：85318032（编程交流）
//           Blog：http://www.cnblogs.com/codelove/
// 
// ======================================================================

using System.IO;
using System.Threading.Tasks;
using Magicodes.ExporterAndImporter.Pdf;
using Magicodes.ExporterAndImporter.Tests.Models;
using Shouldly;
using Xunit;

namespace Magicodes.ExporterAndImporter.Tests
{
    public class PdfExporter_Tests
    {
        [Fact(DisplayName = "导出Pdf测试")]
        public async Task ExportPdf_Test()
        {
            var exporter = new PdfExporter();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), nameof(ExportPdf_Test) + ".pdf");
            if (File.Exists(filePath)) File.Delete(filePath);
            //此处使用默认模板导出
            var result = await exporter.ExportByTemplate(filePath, GenFu.GenFu.ListOf<ExportTestData>());
            result.ShouldNotBeNull();
            File.Exists(filePath).ShouldBeTrue();
        }


        [Fact(DisplayName = "自定义模板导出Pdf测试")]
        public async Task ExportPdfByTemplate_Test()
        {
            var tplPath = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles", "ExportTemplates", "tpl1.cshtml");
            var tpl = File.ReadAllText(tplPath);
            var exporter = new PdfExporter();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), nameof(ExportPdfByTemplate_Test) + ".pdf");
            if (File.Exists(filePath)) File.Delete(filePath);
            //此处使用默认模板导出
            var result = await exporter.ExportByTemplate(filePath,
                GenFu.GenFu.ListOf<ExportTestData>(), tpl);
            result.ShouldNotBeNull();
            File.Exists(filePath).ShouldBeTrue();
        }
    }
}