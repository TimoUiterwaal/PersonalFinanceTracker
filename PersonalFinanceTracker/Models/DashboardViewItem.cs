using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker
{
	public class DashboardViewItem()
	{

		[DataType(DataType.Date)]
		public DateTime InputDate { get; set; } = DateTime.Today;
		public List<Receipt> Receipts {get; set;}
		public List<Transaction>? Transactions { get; set; }
	}
}
