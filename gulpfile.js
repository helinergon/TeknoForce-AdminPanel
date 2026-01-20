// Gulp and package
const {src, dest, parallel, series, watch} = require('gulp');

// Plugins
const autoprefixer = require('autoprefixer');
const concat = require('gulp-concat');
const cssnano = require('cssnano');
const pixrem = require('pixrem');
const plumber = require('gulp-plumber');
const postcss = require('gulp-postcss');
const rename = require('gulp-rename');
const gulUglifyES = require('gulp-uglify-es');
const npmdist = require('gulp-npm-dist');
const replace = require('gulp-replace');
const gulpSass = require('gulp-sass');
const dartSass = require('sass');
const tildeImporter = require('node-sass-tilde-importer');
const rtlcss = require('gulp-rtlcss');


const pluginFile = {
    vendorsCSS: [],
    vendorsJS: []
}
    

const paths = {
    baseSrcAssets: "wwwroot",   // source assets directory
    baseDistAssets: "wwwroot",  // build assets directory
};


const sass = gulpSass(dartSass);
const uglify = gulUglifyES.default;

const processCss = [
    autoprefixer(), // adds vendor prefixes
    pixrem(), // add fallbacks for rem units
];

const minifyCss = [
    cssnano({preset: 'default'}), // minify result
];

const styles = function () {
    const out = paths.baseDistAssets + "/css/";

    return src(paths.baseSrcAssets + "/scss/**/*.scss")
        .pipe(
            sass({
                importer: tildeImporter,
                includePaths: [paths.baseSrcAssets + "/scss"],
            }).on('error', sass.logError),
        )
        .pipe(plumber()) // Checks for errors
        .pipe(postcss(processCss))
        .pipe(dest(out))
        .pipe(rename({suffix: '.min'}))
        .pipe(postcss(minifyCss)) // Minifies the result
        .pipe(dest(out));
};

const rtl = function () {
    const out = paths.baseDistAssets + "/css/";

    return src(paths.baseSrcAssets + "/scss/**/*.scss")
        .pipe(
            sass({
                importer: tildeImporter,
                includePaths: [paths.baseSrcAssets + "/scss"],
            }).on('error', sass.logError),
        )
        .pipe(plumber()) // Checks for errors
        .pipe(postcss(processCss))
        .pipe(dest(out))
        .pipe(rtlcss())
        .pipe(rename({suffix: "-rtl.min"}))
        .pipe(postcss(minifyCss)) // Minifies the result
        .pipe(dest(out));
};


const vendorStyles = function () {
const out = paths.baseDistAssets + "/css/";

return src(pluginFile.vendorsCSS, {sourcemaps: true, allowEmpty: true})
    .pipe(concat('vendors.css'))
    .pipe(plumber()) // Checks for errors
    .pipe(postcss(processCss))
    .pipe(dest(out))
    .pipe(rename({suffix: '.min'}))
    .pipe(postcss(minifyCss)) // Minifies the result
    .pipe(dest(out));
}


const vendorScripts = function () {
    const out = paths.baseDistAssets + "/js/";

    return src(pluginFile.vendorsJS, {sourcemaps: true, allowEmpty: true})
        .pipe(concat('vendors.js'))
        .pipe(dest(out))
        .pipe(plumber()) // Checks for errors
        .pipe(uglify()) // Minifies the js
        .pipe(rename({suffix: '.min'}))
        .pipe(dest(out, {sourcemaps: '.'}));
}


const plugins = function () {
  const out = paths.baseDistAssets + "/libs/";
  return src(npmdist(), { base: "./node_modules" })
    .pipe(rename(function (path) {
      path.dirname = path.dirname.replace(/\/dist/, '').replace(/\\dist/, '');
    }))
    .pipe(dest(out));
};
    

const watchFiles = function () {
    watch(paths.baseSrcAssets + "/scss/**/*.scss", series(styles));
}

// Production Tasks
exports.default = series(
    plugins,
    parallel(styles),
    parallel(watchFiles)
);

// Build Tasks
exports.build = series(
    plugins,
    parallel(styles)
);

// RTL Tasks
exports.rtl = series(
    plugins,
    parallel(rtl),
    parallel(watchFiles)
);

// RTL Build Tasks
exports.rtlBuild = series(
    plugins,
    parallel(rtl),
);