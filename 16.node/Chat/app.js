'use strict';

let express = require('express'),
    bodyParser = require('body-parser'),
    mongoose = require('mongoose');

let app = express();

let port = process.env.PORT || 3030;

let dbPath = 'mongodb://localhost/chat';

require('./models');
// let Message = mongoose.model('Message');

mongoose.connect(dbPath);

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
  extended: true
}));

require('./routes')(app);

app.listen(port, () => console.log(`App running on http://localhost:${port}`));
