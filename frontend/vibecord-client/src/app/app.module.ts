import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChatWrapperComponent } from './chat-wrapper/chat-wrapper.component';
import { ChatInputBarComponent } from './chat-input-bar/chat-input-bar.component';
import { ChatHistoryComponent } from './chat-history/chat-history.component';

@NgModule({
  declarations: [
    AppComponent,
    ChatWrapperComponent,
    ChatInputBarComponent,
    ChatHistoryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
