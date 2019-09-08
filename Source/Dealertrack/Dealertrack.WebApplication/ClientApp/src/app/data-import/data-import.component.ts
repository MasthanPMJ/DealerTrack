import { Component, Inject } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType } from '@angular/common/http';
import { error } from 'protractor';

@Component({
  selector: 'app-data-import',
  templateUrl: './data-import.component.html'
})
export class DataImportComponent {
  public progress: string;
  constructor(private http: HttpClient) { }

  upload(files) {
    if (files.length === 0)
      return;

    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

    const uploadReq = new HttpRequest('POST', `api/deals`, formData, {
      reportProgress: true,
    });

    this.http.request(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        this.progress = "Upload in progress, please wait.";
      else if (event.type === HttpEventType.Response)
        this.progress = "Upload Successful.";
    }, error => { this.progress = "Error in uploading file, please check file format and content."; console.error(error) });
  }
}



