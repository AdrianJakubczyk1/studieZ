var express = require('express'),
    app = express(),
    bodyParser = require('body-parser'),
    methodOverride = require('method-override'),
    expressSanitizer = require('express-sanitizer'),
    mongoose = require('mongoose');



mongoose.connect("mongodb://localhost/restful_Blog", { useNewUrlParser: true });

app.set("view engine", "ejs");
app.use(express.static('public'));
app.use(bodyParser.urlencoded({ extended: true }));
app.use(expressSanitizer());
app.use(methodOverride("_method"));

//mongoose config
var blogSchema = new mongoose.Schema({
    title: String,
    image: String,
    body: String,
    created: { type: Date, default: Date.now }
});

var Blog = mongoose.model("Blog", blogSchema);

// Blog.create({
//     title: "Test Blog",
//     image: "https://secure.img2-fg.wfcdn.com/im/25655915/resize-h310-w310%5Ecompr-r85/5800/58003400/granite-4-drawer-solid-wood-writing-desk.jpg",
//     body: "Blog post"
// })

app.get('/', (req, res) => {
    res.redirect('blogs');
});



app.get("/blogs", (req, res) => {
    Blog.find({}, (err, blogs) => {
        if (err) {
            console.log('error');
        } else {
            res.render("index", { blogs: blogs });
        }
    });
});

app.get("/blogs/new", (req, res) => {
    res.render("new");
});

app.post('/blogs', (req, res) => {

    Blog.create(req.body.blog, (err, blog) => {
        if (err) {
            res.render('new');
        } else {
            res.redirect('/blogs');
        }
    })
})

app.get('/blogs/:id', (req, res) => {
    Blog.findById(req.params.id, (err, found) => {
        if (err) {
            res.redirect('/blogs');
        } else {
            res.render('show', { blog: found });
        }
    })
});

//Update
app.put('/blogs/:id', (req, res) => {
    req.body.blog.body = req.sanitize(req.body.blog.body)
    Blog.findByIdAndUpdate(req.params.id, req.body.blog, (err, updated) => {
        if (err) {
            res.redirect('blogs');
        } else {
            res.redirect('/blogs/' + req.params.id);
        }
    })

})

app.delete('/blogs/:id', (req, res) => {
    Blog.findByIdAndRemove(req.params.id, (err) => {
        if (err) {
            res.redirect('/blogs');
        } else {
            res.redirect('/blogs');
        }
    })
})


app.get("/blogs/:id/edit", (req, res) => {
    Blog.findById(req.params.id, (err, found) => {
        if (err) {
            res.redirect('/blogs');
        } else {
            res.render('edit', { blog: found });
        }
    });
});

var listener = app.listen(8888, function() { console.log('start.') }); //Listening on port 8888