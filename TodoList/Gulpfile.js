const gulp = require('gulp');
const sass = require('gulp-sass');

// Compile SCSS into CSS
function SassStyle() {
    return gulp.src('wwwroot/scss/**/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('wwwroot/css'))
}

// Watch changes then style()
function SassWatch() {
    gulp.watch('wwwroot/scss/**/*.scss', SassStyle)
}

exports.SassStyle = SassStyle;
exports.SassWatch = SassWatch;
