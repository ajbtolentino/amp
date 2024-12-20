const setEnv = () => {
    const fs = require('fs');
    const writeFile = fs.writeFile;
    // Configure Angular `environment.ts` file path
    const targetPath = './src/environments/environment.ts';
    // Load node modules
    const colors = require('colors');
    const appVersion = require('../../package.json').version;
    require('dotenv').config({
        path: '.env'
    });
    // `environment.ts` file structure
    const envConfigFile = `export const environment = {
    IDP_AUTHORITY_HTTPS_URL: '${process.env["IDP_AUTHORITY_HTTPS_URL"]}',
    EMS_SPA_APIURL: '${process.env["EMS_SPA_APIURL"]}',
    EMS_SPA_CLIENTID: '${process.env["EMS_SPA_CLIENTID"]}',
    EMS_SPA_CLIENTSCOPE: '${process.env["EMS_SPA_CLIENTSCOPE"]}',
    EMS_SPA_REDIRECTURL: '${process.env["EMS_SPA_REDIRECTURL"]}',
    production: true,
  };
  `;
    console.log(colors.magenta('The file `environment.ts` will be written with the following content: \n'));
    writeFile(targetPath, envConfigFile, (err: any) => {
        if (err) {
            console.error(err);
            throw err;
        } else {
            console.log(colors.magenta(`Angular environment.ts file generated correctly at ${targetPath} \n`));
        }
    });
};

setEnv();
