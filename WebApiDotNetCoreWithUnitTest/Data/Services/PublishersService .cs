﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApiDotNetCoreWithUnitTest.Data.Models;
using WebApiDotNetCoreWithUnitTest.Data.ViewModels;
using WebApiDotNetCoreWithUnitTest.Exceptions;

namespace WebApiDotNetCoreWithUnitTest.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public List<Publisher> GetAllPublishers() => _context.Publishers.ToList();

        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStartsWithNumber(publisher.Name)) 
                throw new PublisherNameException("Name starts with number", publisher.Name);
            
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
            return _publisher;
        }
        public Publisher GetPublisherById(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                    .Select(n => new PublisherWithBooksAndAuthorsVM()
                    {
                        Name = n.Name,
                        BookAuthors = n.Books.Select(n => new BookAuthorVM()
                        {
                            BookName = n.Title,
                            BookAuthors = n.BookAuthors.Select(n => n.Author.FullName).ToList()
                        }).ToList()
                    }).FirstOrDefault();

            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"The publisher with id: {id} does not exist");
            }
        }

        public bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
        
    }
}