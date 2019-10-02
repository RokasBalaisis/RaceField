# WebSocket API documentation

### Message to Client:

+ {Root}
	+ type
		+ message // chat message from client
		+ mapUpdate // map, settings, players changes
	+ message // if type = message
		+ [string value] // message received
	+ sender // if type = message
		+ {Player}
	+ mapChanges
		+ *not defined*
	+ playerCount
		+ *not defined*
	+ players
		+ [Array of {Player}]

#### Other objects:
+ {Player}
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

### Message to server:
+ {Root}
	+ type
		+ message // chat message
	+ message // if type = message
		+ [string value]

#### Other objects: