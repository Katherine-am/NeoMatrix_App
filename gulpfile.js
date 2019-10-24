'use strict';

var gulp = require('gulp');
var sass = require('gulp-sass');

var sassFiles = 'wwwroot/sass/**/*.scss',
    cssFiles = 'wwwroot/css';

gulp.task('styles', () => { 
    return gulp.src(sassFiles)
    .pipe(sass().on('error', sass.logError))
    .pipe(gulp.dest(cssFiles)); 
});

const sassTask = () => {
    return gulp.series('styles');
}

gulp.task('watch', () => {
    gulp.watch(sassFiles, sassTask);
});

gulp.task('connect', function() {
    connect.server({
        root: '.',
        livereload: true
    })
});