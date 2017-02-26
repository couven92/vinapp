var gulp = require('gulp');
var sass = require('gulp-sass');

gulp.task('styles', function () {
    gulp.src('src/Vinapp.Api/Sass/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('src/Vinapp.Api/wwwroot/css/'));
});