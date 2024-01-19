var io = require('socket.io')({
    transports: ['websocket'],
});
io.attach(4567);
console.log('Server has started');

var Player = require('./Classes/Player.js')

var players = [];
var sockets = [];

io.on('connection', function (socket) {
    console.log('Connection Made!');
    var player = new Player();
    var thisPlayerID = player.id;

    players[thisPlayerID] = player;
    sockets[thisPlayerID] = socket;
    console.log(thisPlayerID)
    //console.log(player)
    socket.emit('register', { id: thisPlayerID });
    socket.emit('spawn', player);
    socket.broadcast.emit('spawn',player)


    //part3 2:30
    socket.on('updatePosition', function (data) {
        console.log('updatePosition');
        player.position.x = data.position.x;
        player.position.y = data.position.y;
        socket.broadcast.emit('updatePosition', player);
        //socket.emit('updatePosition', player);
        console.log(player);
        //console.log('updatePosition');
    });
    

    for (var playerID in players) {
        if (playerID != thisPlayerID) {
            socket.emit('spawn', players[playerID])
        }
    }

    socket.on('disconnect', function () {

        console.log('disconnect');
        delete players[thisPlayerID];
        delete sockets[thisPlayerID];
        socket.broadcast.emit('disconneted', player);

    })
});