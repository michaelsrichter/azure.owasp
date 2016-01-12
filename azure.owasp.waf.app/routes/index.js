var express = require('express');
var router = express.Router();
var os = require("os");

/* GET home page. */
router.get('/', function (req, res) {
    res.render('index', { title: 'Express', hostName: os.hostname(), requestHost: req.headers.host, });
});

module.exports = router;