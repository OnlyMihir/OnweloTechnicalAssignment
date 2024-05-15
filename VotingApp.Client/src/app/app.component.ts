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

  addVoter() {

  }

  addCandidate() {

  }

  title = 'votingapp.client';
}
