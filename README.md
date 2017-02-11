# MyLeague
Soccer leagues management

The example collections are here:

Users collection
```javascript
{
	"person": {
		"id": 1,
		"login": "JDoe",
		"password": "abcdef",
		"first_name": "John",
		"last_name": "Doe",
		"gender": "male",
		"address": { 
			"street": "301 Heights Ln",
			"city": "Feasterville-Trevose",
			"state": "PA",
			"zip": "19053"
		},
		"birth":  "2011-07-14T19:43:37+0100",
		"photo": "Images/Person_123456789.png",
		"contact": {
			"phone": "+1123456789",
			"email": "john.doe@gmail.com",
			"skype": "john.doe"
		},		
		"documents": {
			"season": 1,
			"document": "Documents/Document_123456789.pdf"
		},
		"payments": {
			"season": 1,
			"payment_method": ["check", "cash", "direct deposit"]
		},
		"role": "Right wing-back (RWB)",
		"access_level": {
					"level" : 5, 
					"group" : "dev"
		},		
		"status": "active",
		"notifications": [
			{
				"id": 1,
				"personid": 1,
				"category": "Action",
				"priority": "1",
				"type": "JoinTeam",
				"params": [],
				"status": "closed"
			}
		]
	}
}
```


Teams collection
```javascript
{
	"team": {
		"id": 1,
		"name": "InterStars FC",
		"logo": "Images/InterStarsFC_logo.png",
		"coach": 1,
		"captain": 1,
		"players": [
			{
				"id": 1,
				"personid": 2,
				"shirt_number": "3",
				"role": "Right wing-back (RWB)"
			}
		],
		"colors": {
			"home": "yellow",
			"away": "green",
		},
		"status": "Active"
	}
}
```

Leagues collection
```javascript
{
    "league": {
        "id": 1,
        "type": "Soccer",
        "name": "Bucks County Coed",
		"teams": [ 1 ],
		"seasons": [ 1 ],
		"association": "Bucks County Soccer Association",
		"last_updated": "2011-07-14T19:43:37+0100",
		"address": {
			"street": "125 Upper Holland Rd",
			"city": "Richboro",
			"state": "PA",
			"zip": "18954"
		}
	}
}
```

Seasons collection
```javascript
{
	"season": {
		"id": 1,
		"leagueid": 1,
		"name": "Fall 2015",
		"status": "Active",
		"teams": [
			{
				"id": 1,
				"name": "InterStars FC",
				"logo": "Images/InterStarsFC_logo.png",
				"coach": 1,
				"captain": 1,
				"players": [
					{
						"id": 1,
						"personid": 2,
						"shirt_number": "3",
						"role": "Right wing-back (RWB)"
					}
				],
				"colors": {
					"home": "yellow",
					"away": "green"
				}
			}
		],
		"games": [
			1,
			2
		]
	}
}
```

Pitch collection
```javascript
{
	"pitch": {
		"id": 1,
		"address": { 
			"street": "125 Upper Holland Rd",
			"city": "Richboro",
			"state": "PA",
			"zip": "18954"
		},
		"map": "https://www.google.com/maps/place/Richboro+Elementary+School/@40.2102964,-75.0039346,17z/data=!3m1!4b1!4m2!3m1!1s0x89c6ac988167955b:0x9c290bf1d8543b2d"
	}
}
```

Games collection
```javascript
{
	"game": {
		"id": 1,
		"date": "2011-07-14T19:43:37+0100",
		"teams": {
				"home": {
						"team": 1,
						"score": 1
				},
				"away":	{
						"team": 2,
						"score": 0
				}
		},
		"judges": {
			"main": 1,
			"side1": 2,
			"side2": 3
		},
		"pitch": 1,
		"facts": [
			{
				"time": "2011-07-14T19:43:37+0100",
				"team": 1,
				"player": 2,
				"type": "goal",
				"own": "false"
			},
			{
				"time": "2011-07-14T19:43:37+0100",
				"team": 2,
				"player": 3,
				"type": "card",
				"color": "yellow"
			}
		]
	}
}
```

http://d3js.org/
http://json2csharp.com/
http://jsonlint.com/
http://www.codeproject.com/Articles/868000/Push-Notification-For-Windows-iOS-Android-Quick-Ea
http://www.restapitutorial.com/httpstatuscodes.html
http://stackoverflow.com/questions/4687271/jax-rs-how-to-return-json-and-http-status-code-together
