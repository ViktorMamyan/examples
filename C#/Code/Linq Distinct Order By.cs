var queryCity = services.Select(c => new { c.City })
				.Distinct()
				.OrderBy(x => x.City)
				.Select(x => x.City);
	
comboBox1.DataSource = queryCity.ToList();