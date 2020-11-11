Feature: PlaceOrder
		As a user I want to access place order module
  So that I can perform tasks related to it

@PlaceOrder @UI
Scenario:Place Order
	Given User on home page
	When User clicks Sign in button
	And User enters Valid Credentials to login
	And User hover over Women tab
	And User selects Blouses category
	Then User should be navigated to Blouses page
	When User select product 1 from the resulted products and add it to cart
	Then Product should be added to cart
	When User Checkouts from Confirmation PopUp step
	And User Checkouts from Summary step
	And User Checkouts from Address step
	And User agrees to Terms of service
	And User Checkouts from Shipping step
	Then User should be navigated to PaymentMethod page 
	When User Select Bank wire payment option
	And User confirms the order
	Then Order should be confirmed 
