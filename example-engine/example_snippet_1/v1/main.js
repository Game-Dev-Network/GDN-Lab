exports = function(s1, s2, newline) {
	process.stdout.write(s1.concat(s2).concat(newline ? "\n" : ""));
}
