import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent{

  // constructor(private router: Router) { }

  // ngOnInit(): void {
  //   const redirectedToMVC = sessionStorage.getItem('redirectedToMVC');
  //   if (!redirectedToMVC) {
  //     this.redirectToMVC();
  //     sessionStorage.setItem('redirectedToMVC', 'true'); 
  //   }
  // }

  // redirectToMVC(): void {
  //   window.location.href = 'https://localhost:7206';
  // }

  // @HostListener('window:beforeunload')
  // onBeforeUnload() {
  //   sessionStorage.setItem('redirectedToMVC', 'false');
  // }
}
