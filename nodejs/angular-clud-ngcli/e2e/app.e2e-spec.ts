import { AngularCludNgcliPage } from './app.po';

describe('angular-clud-ngcli App', function() {
  let page: AngularCludNgcliPage;

  beforeEach(() => {
    page = new AngularCludNgcliPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
