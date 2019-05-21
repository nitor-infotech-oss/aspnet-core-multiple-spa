const path = require('path');
const copydir = require('copy-dir');
const rimraf = require('rimraf');
const { execSync } = require('child_process');

function exec(cmd) {
  execSync(cmd, { stdio: 'inherit', env: process.env });
}

const cwd = process.cwd();

['sample-app-1', 'sample-app-2'].forEach(packageName => {
  const appPath = path.resolve(
    __dirname,
    `../../WebApp/wwwroot/${packageName}`,
  );
  console.log(appPath);
  rimraf.sync(appPath);

  copydir(
    path.resolve(__dirname, `../modules/${packageName}/build`),
    appPath,
    function(err) {
      if (err) {
        return console.error(err);
      }
      return console.log('done!');
    },
  );
});

process.chdir(cwd);
