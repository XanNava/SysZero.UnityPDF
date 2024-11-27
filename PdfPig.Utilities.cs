using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;
using UnityEngine;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.Standard14Fonts;
using UglyToad.PdfPig.Writer;
using System.IO;

namespace SysZero.Unity.PDF {
	internal static class PdfPig {
		public class METHODS {
			public string ReadPDF(string filename) {
				if (!System.IO.File.Exists(filename)) {
					Debug.LogWarning($"PDF doesn't exist at filename='{filename}'");
					return null;
				}

				using (PdfDocument document = PdfDocument.Open(filename)) {
					foreach (Page page in document.GetPages()) {
						string pageText = page.Text;

						foreach (Word word in page.GetWords()) {
							return word.Text;
						}
					}
				}

				return null;
			}

			public void WritePDF(string filePath, byte[] message) {
				var builder = new PdfDocumentBuilder();

				builder.AddPage(PageSize.A4);

				builder.AddStandard14Font(Standard14Font.Helvetica);

				try {
					File.WriteAllBytes(filePath, message);
				}
				catch (Exception e) {
					Debug.LogException(e);
				}
			}
		}
	}
}
