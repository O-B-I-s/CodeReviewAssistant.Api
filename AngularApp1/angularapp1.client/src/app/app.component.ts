import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CodeReviewComponent } from './Components/code-review/code-review.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CodeReviewComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'code-reviewer-ui';
}
