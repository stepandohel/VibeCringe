import { Component, EventEmitter, Output } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';
import { Message } from '../messages';

@Component({
  selector: 'app-chat-input-bar',
  templateUrl: './chat-input-bar.component.html',
  styleUrls: ['./chat-input-bar.component.css']
})
export class ChatInputBarComponent {
  
  text : string = "";
  
  id : number = 1;

  @Output() addMessageNotify = new EventEmitter();

  @Output() sbj = new Subject<Message>();

  sendMessage(text:string):void {
  this.sbj.next(new Message(1,this.text));
  }

}
