namespace PersonalFinanceTracker
{
	public class ImporterUtility(ApplicationDbContext _context)
	{
		//pass enums to indicate which path they should look at

		//Primary constructor takes care of setting the property
		//ApplicationDbContext Context { get; set; } = _context;
		readonly SystemSetup _systemSetup = _context.SystemSetup.FirstOrDefault() ?? throw new InvalidOperationException("SystemSetup has no rows; run setup first.");
		public bool CheckBasePathExists(ImportTypes import) => Directory.Exists(GetBasePathFolder(import));
		public void BuildBasePathDirectory(ImportTypes import) => Directory.CreateDirectory(GetBasePathFolder(import));
		public bool CheckBasePathContainsFiles(string extension, ImportTypes import) => Directory.GetFiles(GetBasePathFolder(import), $"*{extension}").Length > 0;
		public string[] GetBasePathFilePaths(string extension, ImportTypes import) => Directory.GetFiles(GetBasePathFolder(import), $"*{extension}");
		public void RemoveBasePathFiles(string extension, ImportTypes import)
		{
			foreach (var file in GetBasePathFilePaths(extension, import))
			{
				File.Delete(file);
			}
		}
		public string GetBasePathFolder(ImportTypes import) => _systemSetup.BasePath + "\\" + import.ToString();
		
	}
}
