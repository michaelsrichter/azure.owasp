var express = require('express');
var nconf = require('nconf');
var router = express.Router();

nconf.file('conf.json').env();

/* GET home page. */
router.get('/', function (req, res) {
    res.render('index', {
        title: 'Express',
        confMessage: nconf.get('CONF_MESSAGE'),
        message1: nconf.get('MESSAGE_1')
    });
});

module.exports = router;