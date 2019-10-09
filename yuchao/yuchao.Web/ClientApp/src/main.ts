import { enableProdMode, ViewEncapsulation } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

import { preloaderFinished } from '@delon/theme';
preloaderFinished();

import { hmrBootstrap } from './hmr';

if (environment.production) {
  enableProdMode();
}
export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

const providers = [{ provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }];
const bootstrap = () => {
  return platformBrowserDynamic(providers)
    .bootstrapModule(AppModule, {
      defaultEncapsulation: ViewEncapsulation.Emulated,
      preserveWhitespaces: false,
    })
    .then(res => {
      if ((window as any).appBootstrap) {
        (window as any).appBootstrap();
      }
      return res;
    });
};

if (environment.hmr) {
  // tslint:disable-next-line: no-string-literal
  if (module['hot']) {
    hmrBootstrap(module, bootstrap);
  } else {
    console.error('HMR is not enabled for webpack-dev-server!');
    console.log('Are you using the --hmr flag for ng serve?');
  }
} else {
  bootstrap();
}
