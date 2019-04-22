Feature: EbaySearch
	In order to search products
	As an online user
	I want to perform a search

Scenario: Search shoes ordered by price ascending
	Given I have opened the ebay page
	When I type the 'puma shoes' search text	
	And I press the search button
	And  I sort products by 'Price + Shipping: lowest first' order
	And I select the 'New with box' condition
	Then The products are displayed in the correct order
	| ProductName																			|	
	| Puma evoknit FTB II it Indoor 43 NEU70 € Football Indoor Shoes Evopower Future One    |
	| New Boys Girl Infants Kids Puma Unisex Suede Trainers xmas gift				        |
	| Puma evoknit FTB II it Indoor 40 NEU70 € Football Indoor Shoes Evopower Future One    |
	| Puma Evospeed Sala 3.4 JR Junior Trainers Indoor Shoes Lace Up 103462 09 U31          |
	| Puma Tsugi-Mi evoknit Su Sneaker Trainers Shoes Lifestyle Size 43 NEW LP:139 €        |

Scenario: Search shoes ordered by price descending
	Given I have opened the ebay page
	When I type the 'puma shoes' search text	
	And I press the search button
	And  I sort products by 'Price + Shipping: highest first' order
	And I select the 'New with box' condition
	Then The products are displayed in the correct order
	| ProductName																			|	
	| Puma Shoe Bootie Sneakers Suede Pink Suede Classic 363242-46        					|
	| Puma RS Computer 1986-2018 #44 of 86 Pairs Worldwide New in Box US 10 UK 9 EUR 43     |
	| Puma RS Computer 1986-2018 #62 of 86 Pairs Worldwide New in Box US 10 UK 9 EUR 43     |
	| RS-X Mixtape Alexander John 2018 Complex Con Puma Sneaker						        |
	| Puma rs-computer new in box 83/86 us size 9.5									        |