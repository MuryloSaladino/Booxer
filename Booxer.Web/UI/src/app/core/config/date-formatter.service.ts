import { CalendarDateFormatter, DateFormatterParams } from 'angular-calendar';
import { Injectable } from '@angular/core';
import { formatDate } from '@angular/common';

@Injectable()
export class CustomDateFormatter extends CalendarDateFormatter {

    override weekViewHour({ date, locale }: DateFormatterParams): string {
        return formatDate(date, 'HH\'h\'', locale!);
    }
}
