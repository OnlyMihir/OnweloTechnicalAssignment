import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Candidate {
  id: string;
  name: string;
  votes: number;
}

interface Voter {
  id: string;
  name: string;
  hasVoted: boolean;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public candidates: Candidate[] = [];
  public voters: Voter[] = [];
  public showAddVoterRow: boolean = false;
  public newVoterName: string = "";
  public showAddCandidateRow: boolean = false;
  public newCandidateName: string = "";

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getCandidates();
    this.getVoters();
  }

  getCandidates() {
    this.http.get<Candidate[]>('/api/voting/candidates').subscribe(
      (result) => {
        this.candidates = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getVoters() {
    this.http.get<Voter[]>('/api/voting/voters').subscribe(
      (result) => {
        this.voters = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  toggleAddVoterRow() {
    this.showAddVoterRow = !this.showAddVoterRow;
  }

  saveVoter() {
    if (this.newVoterName.trim() !== '') {
      const voterData = { Name: this.newVoterName, type: 1 };
      this.http.post<any>('/api/voting/addentity', voterData).subscribe(
        (response) => {
          this.voters.push({ id: response, name: this.newVoterName, hasVoted: false });
          this.newVoterName = '';
          this.showAddVoterRow = false;
        },
        (error) => {
          console.error(error);
        }
      );
    }
  }

  toggleAddCandidateRow() {
    this.showAddCandidateRow = !this.showAddCandidateRow;
  }

  saveCandidate() {
    if (this.newCandidateName.trim() !== '') {
      const candidateData = { Name: this.newCandidateName, type: 0 };
      this.http.post<any>('/api/voting/addentity', candidateData).subscribe(
        (response) => {
          this.candidates.push({ id: response, name: this.newCandidateName, votes: 0 });
          this.newCandidateName = '';
          this.showAddCandidateRow = false;
        },
        (error) => {
          console.error(error);
        }
      );
    }
  }

  title = 'votingapp.client';
}
