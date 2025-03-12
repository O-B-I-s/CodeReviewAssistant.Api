import { Component, ElementRef, OnInit, Renderer2, ViewChild, inject } from '@angular/core';
import { ICodeReview } from '../../Models/Interface/ICodeReview';
import { HttpClient } from '@angular/common/http';
import { MasterService } from '../../Services/master.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-code-review',
  standalone: true,
  templateUrl: './code-review.component.html',
  styleUrls: ['./code-review.component.css'],
  imports : [FormsModule, CommonModule],
})
export class CodeReviewComponent implements OnInit {

  codeReview: ICodeReview[] = [];
  

  masterService = inject(MasterService)

    ngOnInit(): void {
      this.masterService.getAllCodeReviews().subscribe((result: ICodeReview[]) => {
        this.codeReview = result;
        console.log(result);

      })
    }
}
