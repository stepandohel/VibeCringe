import { Component, Input } from '@angular/core';
import { BehaviorSubject } from 'rxjs';


import { Message } from '../messages';

@Component({
  selector: 'app-chat-history',
  templateUrl: './chat-history.component.html',
  styleUrls: ['./chat-history.component.css']
})
export class ChatHistoryComponent {
    @Input() messages: Array<Message>=[];
}
