﻿import { Component, Input, Output } from '@angular/core';
import { ConfigurationSetSummary } from '../interfaces/configurationSetSummary';
import { UploadDataService } from '../dataservices/upload-data.service';

@Component({
    selector: 'configSet-overview',
    template: `
        <div class="group">
            <h4>{{configurationSet.name}}</h4>
            <p>{{configurationSet.description}}</p>
            <button type="button" (click)="downloadConfigSet(configurationSet.configurationSetId)">Download</button>
            <json-file-uploader [(csMessage)]="uploadMessage" (onUpload)="uploadConfigSet($event)"></json-file-uploader>            
            <h4>Configurations</h4>
            <config-overview *ngFor="let config of configurationSet.configs" [csConfig]="config" [csClientId]="clientId" [csConfigurationSetId]="configurationSet.configurationSetId">
            </config-overview>
        </div>
`
})
export class ConfigurationSetComponent {
    @Input('csConfigurationSet')
    configurationSet: ConfigurationSetSummary;
    @Input('csClientId')
    clientId: string;

    uploadMessage: string;
    constructor(private uploadService: UploadDataService) {

    }

    downloadConfigSet(configurationSetId: string) {
        window.open('download/' + this.clientId + '/' + configurationSetId + '.json');
    }

    uploadConfigSet(value: any): void {
        this.uploadService.postConfigSet(this.clientId, this.configurationSet.configurationSetId, value)
                .then(success => {
                    if (!success)
                        this.uploadMessage = 'Invalid Config';
                });
        }
}