Feature: EbayProductAccess

	Access a Product via category after applying multiple filters
	Access a Product via Search


@tc_001
Scenario: Access a Product via category after applying multiple filters
	Given Open the Ebay site
	When User navigate to Shop by category > Electronics > 'Cell phones & accessories'
	And  click on 'Cell Phones & Smartphones' link
	And click on 'All Filters' btn
	And Add filter on 'Condition' -> select 'New' option
	And Add filter on 'Price' -> select range '300' to '500' dollars
	And Add filter on 'Item Location' -> select 'Worldwide' option
	And User click on Apply btn
	Then Validate all the filter tags are applied successfully


@tc_002
Scenario: Access a Product via Search
	Given Open the Ebay site
	When User Search 'MacBook' item
	And select the category as 'Computers/Tablets & Networking'
	Then Verify the first result name matches with the searched item name i.e.,'MacBook'