import { AngularRutePage } from './app.po';

describe('angular-rute App', function() {
  let page: AngularRutePage;

  beforeEach(() => {
    page = new AngularRutePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
