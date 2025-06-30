import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import dayjs from 'dayjs';
import isoWeek from 'dayjs/plugin/isoWeek';

@Component({
    selector: 'app-root',
	template: '<router-outlet/>',
    standalone: true,
	imports: [RouterOutlet],
})
export class AppComponent implements OnInit {

    readonly title = 'Booxer';

    ngOnInit() {
        dayjs.extend(isoWeek);
    }
}
