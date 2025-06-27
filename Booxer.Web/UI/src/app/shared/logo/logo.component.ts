import { Component, Input } from '@angular/core';

export type LogoSize = 'sm' | 'md' | 'lg'

@Component({
	selector: 'booxer-logo',
	templateUrl: './logo.component.html',
	styleUrl: './logo.component.css',
	standalone: true,
	imports: []
})
export class LogoComponent {

    @Input() size: LogoSize = 'md';
}
