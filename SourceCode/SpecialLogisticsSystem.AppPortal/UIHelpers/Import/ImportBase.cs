using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Model;
using System.IO;
using Aspose.Cells;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers.Import
{
    public abstract class ImportBase
    {
        public static string Import(ImportType importType, string newFileName)
        {
            string result = string.Empty;
            try
            {
                Workbook book = new Workbook(newFileName);
                Cells cells = book.Worksheets[0].Cells;
                switch (importType)
                {
                    case ImportType.Customer:
                        result=new ImportCustomer().Import(cells);
                        break;
                    case  ImportType.Way:
                        result = new ImportWay().Import(cells);
                        break;
                    case ImportType.Stowage:
                        result = new ImportStowage().Import(cells);
                        break;
                    default:
                        break;
                }
            }
            finally
            {
                if (File.Exists(newFileName))
                    File.Delete(newFileName);
            }
            return result;
        }
        protected abstract string Import(Cells cells);
    }
}