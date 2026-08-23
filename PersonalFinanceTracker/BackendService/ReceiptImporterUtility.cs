namespace PersonalFinanceTracker
{
	public class ReceiptImporterUtility(ApplicationDbContext _context)
	{
		//Primary constructor takes care of setting the property
		//ApplicationDbContext Context { get; set; } = _context;
		readonly SystemSetup _systemSetup = _context.SystemSetup.FirstOrDefault() ?? throw new InvalidOperationException("SystemSetup has no rows; run setup first.");
		public bool CheckBasePathExists() => Directory.Exists(_systemSetup.BasePath);
		public void BuildBasePathDirectory() => Directory.CreateDirectory(_systemSetup.BasePath);
		public bool CheckBasePathContainsFiles(string extension) => Directory.GetFiles(_systemSetup.BasePath, $"*{extension}").Length > 0;
		public string[] GetBasePathFilePaths(string extension) => Directory.GetFiles(_systemSetup.BasePath, extension);
	}
}
