import { Component, inject, OnInit } from '@angular/core';
import { ChangeDetectorRef } from '@angular/core';

import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'c-view',
  templateUrl: './c-view.component.html',
  styleUrls: ['./c-view.component.css']
})
export class CViewComponent implements OnInit {
  constructor(private http:HttpClient){}
  data:any[]=[];
  selectedCandidate:any = null;
  showDeleteModal: boolean = false;
  candidateToDelete: any = null;
  newCandidate: any = null;  // Store new candidate data
  showAddModal: boolean = false;  // Control display of add modal


  candidateGet = 'https://localhost:7183/Get/Candidate'
  candidateDelete = 'https://localhost:7183/Delete/Candidate';
  candidateUpdate = 'https://localhost:7183/Update/Details';
  candidateAdd = 'https://localhost:7183/Add/Candidate';
  candidateTypeMaster = 'https://localhost:7183/Get/CandidateMaster';
  candidateAvailability = 'https://localhost:7183/Get/Availability';

  ngOnInit(): void {
      this.getData();
      this.getCandidateMaster();
      this.getAvailability();
  }
  getData(){
    this.http.get<any>(this.candidateGet).subscribe( response => {
      this.data=response;
      console.log('Data fetched successfully:', this.data);
    })
  }

  openUpdateModal(candidate: any) {
    this.selectedCandidate = { ...candidate };  // Copy candidate data for editing
  }

  updateData() {
    if (this.selectedCandidate) {
      console.log(this.selectedCandidate);
      this.http.put(this.candidateUpdate, this.selectedCandidate).subscribe(
        (response) => {
          console.log('Update successful', response);
          this.getData();  // Refresh the list after update
          this.closeUpdateModal();  // Close the modal
        },
        error => {
          console.error('Error updating candidate:', error);
        }
      );
    }
  }

  // Close the update modal
  closeUpdateModal() {
    this.selectedCandidate = null;  // Clear selected candidate data
  }

  //delete modals
   // Open Delete Modal
   openDeleteModal(candidate: any) {
    this.candidateToDelete = candidate;
    this.showDeleteModal = true;
  }

  // Close Delete Modal
  closeDeleteModal() {
    this.showDeleteModal = false;
    this.candidateToDelete = null;
  }

  // Delete Candidate Data
  deleteUser() {
    if (this.candidateToDelete) {
      const deleteRequest = { Id: this.candidateToDelete.id };  // Create object with ID
  
      this.http.delete(this.candidateDelete, { body: deleteRequest }).subscribe(
        (response) => {
          console.log('Delete successful', response);
          this.getData();  // Refresh data after deletion
          this.closeDeleteModal();  // Close modal after deletion
        },
        (error) => {
          console.error('Error deleting candidate:', error);
        }
      );
    }
  }

  //Add candidate pop-up 
  openAddModal() {
    this.newCandidate = {};  // Initialize with empty object
    this.showAddModal = true;
  }

  addCandidate(){
    if(this.newCandidate){
      console.log(this.newCandidate);
      this.http.post(this.candidateAdd, this.newCandidate).subscribe((response)=>{
        console.log("Candidate created Successfully!", response);
        this.getData();
        this.closeAddModal();
        
      },
      (error)=>{
        console.error("Error while adding candidate!",error)
      }
    );
    }
  }

  closeAddModal() {
    this.newCandidate = null;  // Clear form data
    this.showAddModal = false;
  }

  //cadidatemasterData
  master:any[] = [];
  getCandidateMaster(){
    this.http.get<any>(this.candidateTypeMaster).subscribe((response)=>{
      this.master = response;
      console.log(this.master);
    },
    (error)=>{
      console.error("Error in candidate type", error);
    }
  );
  }

  //Availability Master Data
  isAvailability: any[] = [];
  getAvailability(){
    this.http.get<any>(this.candidateAvailability).subscribe((response)=>{
      this.isAvailability = response;
      console.log(this.isAvailability);
    },
    (error)=>{
      console.error("Error in Availability:", error);
    }
  );
  }
}



