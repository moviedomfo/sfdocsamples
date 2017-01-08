import { AngularRute2Page } from './app.po';

describe('angular-rute2 App', function() {
  let page: AngularRute2Page;

  beforeEach(() => {
    page = new AngularRute2Page();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
