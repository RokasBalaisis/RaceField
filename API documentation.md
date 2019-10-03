[MD editor](https://pandao.github.io/editor.md/en.html "MD editor")
# WebSocket API documentation

### Message to Client:

+ {Root}
	+ type
		+ message // chat message from client
		+ mapUpdate // map, settings, players changes
		+ mapSetup // map, settings, players full detailed information
	+ message // if type = message
		+ [string value] // message received
	+ sender // if type = message
		+ {Player}
	+ changesCount // if type = mapUpdate
		+ [int vlaue]
	+ mapChanges // if type = mapUpdate 
		+ PlayerChange
			+ [Array of *not defined*]
		+ ObstacleChange
		+ CollectableChanges
	+ playerCount // if type = mapSetup
		+ *not defined*
	+ players // if type = mapSetup
		+ [Array of {PlayerObject}]
	+ myData // if type = mapSetup
		+ {PlayerPrivate}

#### Other objects:
+ {PlayerObject}
	+ [int value] // player id
		+ {PlayerPub}
+ {PlayerPub}
	+ nickname
		+ [string value]
	+ color
		+ [Color.Name value]
	+ location
		+ X
			+ [int value]
		+ Y
			+ [int value]
	+ rotation
		+ [float value]
	+ carModel
		+ [int value] // default = 0
+ {PlayerPrivate}
	+ id
		+ [int value]
	+ nickname
		+ [string value]
	+ username
		+ [string value]
	+ color
		+ [Color.Name value]
	+ location
		+ X
			+ [int value]
		+ Y
			+ [int value]
	+ rotation
		+ [float value]
	+ carModel
		+ [int value] // default = 0

### Message to server:
+ {Root}
	+ type
		+ message // chat message
	+ message // if type = message
		+ [string value]

#### Other objects: