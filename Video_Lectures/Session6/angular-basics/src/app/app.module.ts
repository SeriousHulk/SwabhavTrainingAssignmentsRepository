import { NgModule } from '@angular/core';

import { WelcomeComponent } from './welcome.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { EventpropbindComponent } from './eventpropbind/eventpropbind.component';
import { SwabhavModule } from './swabhav/swabhav.module';

@NgModule({
  declarations: [    
    WelcomeComponent,
    HeaderComponent,
    FooterComponent,
    EventpropbindComponent
  ],
  imports: [
    SwabhavModule
  ],
  providers: [],
  bootstrap: [WelcomeComponent]
})
export class AppModule { }
