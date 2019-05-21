const path = require('path');
const { execSync } = require('child_process');

function exec(cmd) {
  execSync(cmd, { stdio: 'inherit', env: process.env });
}

const cwd = process.cwd();

['sample-app-1', 'sample-app-2'].forEach(packageName => {
  process.chdir(path.resolve(__dirname, `../modules/${packageName}`));
  exec('yarn build');
});

process.chdir(cwd);
