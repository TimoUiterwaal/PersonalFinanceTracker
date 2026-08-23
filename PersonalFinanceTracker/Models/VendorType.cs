using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker
{
	/// <summary>
	/// Merchant Category Codes (MCC, ISO 18245) as used by Visa and Mastercard.
	/// Values are the real four-digit MCCs, so they interoperate with card feeds
	/// and bank statement imports. 0 is deliberately unassigned and means "not set".
	/// </summary>
	public enum VendorType
	{
		// Food & Dining
		[Display(Name = "Grocery Stores & Supermarkets")]
		GroceryStores = 5411,
		[Display(Name = "Bakeries")]
		Bakeries = 5462,
		[Display(Name = "Convenience & Specialty Food Stores")]
		ConvenienceStores = 5499,
		[Display(Name = "Restaurants")]
		Restaurants = 5812,
		[Display(Name = "Bars & Nightclubs")]
		BarsAndNightclubs = 5813,
		[Display(Name = "Fast Food")]
		FastFood = 5814,
		[Display(Name = "Liquor Stores")]
		LiquorStores = 5921,

		// Fuel & Automotive
		[Display(Name = "Service Stations")]
		ServiceStations = 5541,
		[Display(Name = "Automated Fuel Dispensers")]
		AutomatedFuelDispensers = 5542,
		[Display(Name = "Car & Truck Dealers")]
		CarAndTruckDealers = 5511,
		[Display(Name = "Auto Parts & Accessories")]
		AutoPartsAndAccessories = 5533,
		[Display(Name = "Auto Service Shops")]
		AutoServiceShops = 7538,
		[Display(Name = "Car Washes")]
		CarWashes = 7542,
		[Display(Name = "Parking Lots & Garages")]
		ParkingAndGarages = 7523,

		// Travel & Transportation
		[Display(Name = "Commuter & Local Transport")]
		CommuterTransport = 4111,
		[Display(Name = "Taxis & Rideshare")]
		TaxisAndRideshare = 4121,
		[Display(Name = "Cruise Lines")]
		CruiseLines = 4411,
		[Display(Name = "Airlines")]
		Airlines = 4511,
		[Display(Name = "Travel Agencies & Tour Operators")]
		TravelAgencies = 4722,
		[Display(Name = "Tolls & Bridge Fees")]
		TollsAndBridgeFees = 4784,
		[Display(Name = "Hotels & Lodging")]
		HotelsAndLodging = 7011,
		[Display(Name = "Car Rental")]
		CarRental = 7512,

		// General Retail
		[Display(Name = "Wholesale Clubs")]
		WholesaleClubs = 5300,
		[Display(Name = "Discount Stores")]
		DiscountStores = 5310,
		[Display(Name = "Department Stores")]
		DepartmentStores = 5311,
		[Display(Name = "General Merchandise")]
		GeneralMerchandise = 5399,
		[Display(Name = "Miscellaneous Specialty Retail")]
		SpecialtyRetail = 5999,

		// Apparel & Accessories
		[Display(Name = "Women's Clothing")]
		WomensClothing = 5621,
		[Display(Name = "Family Clothing")]
		FamilyClothing = 5651,
		[Display(Name = "Shoe Stores")]
		ShoeStores = 5661,
		[Display(Name = "Men's & Women's Clothing")]
		MensAndWomensClothing = 5691,

		// Home, Garden & Furnishings
		[Display(Name = "Home Supply Warehouse Stores")]
		HomeSupplyWarehouse = 5200,
		[Display(Name = "Lumber & Building Materials")]
		LumberAndBuildingMaterials = 5211,
		[Display(Name = "Hardware Stores")]
		HardwareStores = 5251,
		[Display(Name = "Nurseries & Garden Supply")]
		NurseriesAndGardenSupply = 5261,
		[Display(Name = "Furniture & Home Furnishings")]
		FurnitureAndHomeFurnishings = 5712,
		[Display(Name = "Household Appliances")]
		HouseholdAppliances = 5722,

		// Electronics, Software & Digital
		[Display(Name = "Computers & Peripherals")]
		ComputersAndPeripherals = 5045,
		[Display(Name = "Electronics Stores")]
		ElectronicsStores = 5732,
		[Display(Name = "Computer Software Stores")]
		ComputerSoftwareStores = 5734,
		[Display(Name = "Digital Goods - Media, Books, Movies, Music")]
		DigitalGoodsMedia = 5815,
		[Display(Name = "Digital Goods - Games")]
		DigitalGoodsGames = 5816,

		// Specialty Retail
		[Display(Name = "Sporting Goods Stores")]
		SportingGoods = 5941,
		[Display(Name = "Book Stores")]
		BookStores = 5942,
		[Display(Name = "Office & School Supply Stores")]
		OfficeAndSchoolSupplies = 5943,
		[Display(Name = "Jewelry & Watches")]
		JewelryAndWatches = 5944,
		[Display(Name = "Hobby, Toy & Game Shops")]
		HobbyToyAndGameShops = 5945,
		[Display(Name = "Gift, Card & Novelty Shops")]
		GiftAndNoveltyShops = 5947,
		[Display(Name = "Florists")]
		Florists = 5992,
		[Display(Name = "Pet Shops & Supplies")]
		PetShopsAndSupplies = 5995,

		// Health & Medical
		[Display(Name = "Drug Stores & Pharmacies")]
		DrugStoresAndPharmacies = 5912,
		[Display(Name = "Doctors & Physicians")]
		DoctorsAndPhysicians = 8011,
		[Display(Name = "Dentists & Orthodontists")]
		DentistsAndOrthodontists = 8021,
		[Display(Name = "Optometrists & Ophthalmologists")]
		Optometrists = 8042,
		[Display(Name = "Hospitals")]
		Hospitals = 8062,
		[Display(Name = "Other Medical Services")]
		OtherMedicalServices = 8099,

		// Personal Services
		[Display(Name = "Laundry & Garment Services")]
		LaundryAndGarmentServices = 7210,
		[Display(Name = "Beauty & Barber Shops")]
		BeautyAndBarberShops = 7230,
		[Display(Name = "Funeral Services")]
		FuneralServices = 7261,
		[Display(Name = "Tax Preparation Services")]
		TaxPreparation = 7276,
		[Display(Name = "Health & Beauty Spas")]
		HealthAndBeautySpas = 7298,

		// Home Services & Repair
		[Display(Name = "Heating, Plumbing & Air Conditioning")]
		PlumbingAndHvacContractors = 1711,
		[Display(Name = "Electrical Contractors")]
		ElectricalContractors = 1731,
		[Display(Name = "Cleaning & Janitorial Services")]
		CleaningServices = 7349,
		[Display(Name = "Miscellaneous Repair Shops")]
		RepairShops = 7699,

		// Utilities & Telecom
		[Display(Name = "Telecom Equipment & Phone Sales")]
		TelecomEquipment = 4812,
		[Display(Name = "Telecommunication Services")]
		TelecomServices = 4814,
		[Display(Name = "Cable, Satellite & Streaming Services")]
		CableAndStreaming = 4899,
		[Display(Name = "Utilities - Electric, Gas, Water, Sanitary")]
		Utilities = 4900,

		// Financial Services
		[Display(Name = "Money Transfer & Wire Transfer")]
		MoneyTransfer = 4829,
		[Display(Name = "ATM Cash Withdrawals")]
		AtmCashWithdrawals = 6011,
		[Display(Name = "Currency Exchange & Crypto")]
		CurrencyExchangeAndCrypto = 6051,
		[Display(Name = "Securities Brokers & Dealers")]
		SecuritiesBrokers = 6211,
		[Display(Name = "Insurance Premiums")]
		Insurance = 6300,

		// Professional & Business Services
		[Display(Name = "Consulting & Management Services")]
		ConsultingServices = 7392,
		[Display(Name = "Legal Services & Attorneys")]
		LegalServices = 8111,
		[Display(Name = "Accounting & Bookkeeping")]
		AccountingAndBookkeeping = 8931,
		[Display(Name = "Other Professional Services")]
		OtherProfessionalServices = 8999,

		// Education & Childcare
		[Display(Name = "Elementary & Secondary Schools")]
		Schools = 8211,
		[Display(Name = "Colleges & Universities")]
		CollegesAndUniversities = 8220,
		[Display(Name = "Other Educational Services")]
		OtherEducationalServices = 8299,
		[Display(Name = "Child Care Services")]
		ChildCare = 8351,

		// Membership & Charitable Organizations
		[Display(Name = "Charitable & Social Service Organizations")]
		CharitableOrganizations = 8398,
		[Display(Name = "Religious Organizations")]
		ReligiousOrganizations = 8661,
		[Display(Name = "Other Membership Organizations")]
		MembershipOrganizations = 8699,

		// Entertainment & Recreation
		[Display(Name = "Movie Theaters")]
		MovieTheaters = 7832,
		[Display(Name = "Theaters & Ticket Agencies")]
		TheatersAndTicketAgencies = 7922,
		[Display(Name = "Sports Clubs & Athletic Fields")]
		SportsClubs = 7941,
		[Display(Name = "Tourist Attractions & Exhibits")]
		TouristAttractions = 7991,
		[Display(Name = "Gambling & Casinos")]
		GamblingAndCasinos = 7995,
		[Display(Name = "Amusement Parks & Carnivals")]
		AmusementParks = 7996,
		[Display(Name = "Membership & Country Clubs")]
		MembershipClubs = 7997,

		// Shipping & Storage
		[Display(Name = "Freight & Moving Services")]
		FreightAndMoving = 4214,
		[Display(Name = "Courier Services")]
		CourierServices = 4215,
		[Display(Name = "Public Warehousing & Storage")]
		WarehousingAndStorage = 4225,

		// Government
		[Display(Name = "Court Costs, Alimony & Child Support")]
		CourtCosts = 9211,
		[Display(Name = "Tax Payments")]
		TaxPayments = 9311,
		[Display(Name = "Government Services")]
		GovernmentServices = 9399,

		// Direct Marketing & Subscriptions
		[Display(Name = "Catalog Merchants")]
		CatalogMerchants = 5964,
		[Display(Name = "Subscription & Continuity Merchants")]
		SubscriptionMerchants = 5968
	}
}
