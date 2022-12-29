﻿using System.Collections.Generic;
using ASRR.Revit.Core.Elements;
using Autodesk.Revit.DB;
using NLog;

namespace ASRR.Revit.Core.Exporter
{
    public static class ExportUtilities
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static void ExportPNG(Document document, string exportPath)
        {
            var view = Utilities.Get3dView(document);
            var opt = new ImageExportOptions
            {
                ZoomType = ZoomFitType.FitToPage,
                PixelSize = 600,
                FilePath = exportPath,
                FitDirection = FitDirectionType.Horizontal,
                HLRandWFViewsFileType = ImageFileType.PNG,
                ImageResolution = ImageResolution.DPI_600,
                ExportRange = ExportRange.SetOfViews,
                ViewName = exportPath,
            };
            var ids = new List<ElementId> { view.Id };
            opt.SetViewsAndSheets(ids);
            document.ExportImage(opt);
            Log.Info($"Exporting PNG to: {exportPath}");
        }
    }
}