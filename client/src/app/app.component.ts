import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { NgIf } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  imports: [FormsModule, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  name = '';
  email = '';
  university = '';
  phone = '';
  interest = '';

  constructor(private http: HttpClient) {}

  onSubmit(form: NgForm) {
    // Stops if any field fails frontend validation (required, pattern, email)
    if (form.invalid) {
      form.control.markAllAsTouched(); // shows red borders on all invalid fields
      return;
    }

    const data = {
      name: this.name,
      email: this.email,
      university: this.university,
      phone: this.phone,
      interest: this.interest
    };

    this.http.post('http://localhost:5177/register', data).subscribe({
      next: () => {
        alert('Registration Successful!');
        form.resetForm();
      },
      error: (error) => {
        // Shows the exact message from the backend e.g. "Phone number must be 10 to 15 digits."
        const msg = error?.error?.message || 'Something went wrong.';
        alert(msg);
      }
    });
  }
}